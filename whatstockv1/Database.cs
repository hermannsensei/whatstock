using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
    

namespace whatstockv1
{
    class Database
    {

       
        public SQLiteConnection myConn;

        public Database()
        {
            
            myConn  = new SQLiteConnection("Data Source = msgstore.db");
        }
        public Database(string source)
        {
            myConn = new SQLiteConnection("Data Source = "+source);

        }

        internal ChatList sauvegarde
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<Contact> ListeContacts()
        {
            new Database("wa.db");
            var liste = new List<Contact>();
            String query = "select jid, display_name, status, status_timestamp,number,raw_contact_id from wa_contacts where is_whatsapp_user = 1 and raw_contact_id not null order by display_name";
            SQLiteCommand myCmd = new SQLiteCommand(query, this.myConn);
            this.openConnection();
            SQLiteDataReader rslt = myCmd.ExecuteReader();
            if (rslt.HasRows)
            {

                while (rslt.Read())
                {
                    Contact c = new Contact(rslt["display_name"].ToString(), rslt["status"].ToString(), convert(rslt["number"].ToString()), convert(rslt["status_timestamp"].ToString()), convert(rslt["raw_contact_id"].ToString()), rslt["jid"].ToString());
                    
                    liste.Add(c);
                }
            }
            this.closeConnection();
            return liste;

        }
        public String searchIdContact( String nom)
        {
            String jid = "";
            new Database("wa2.db");
            var liste = new List<Contact>();
            String query = "select jid from wa_contacts where is_whatsapp_user = 1 and display_name like @param or jid like @param ";
            SQLiteCommand myCmd = new SQLiteCommand(query, this.myConn);
            this.openConnection();
            myCmd.Parameters.Add(new SQLiteParameter("@param", nom));
            SQLiteDataReader rslt = myCmd.ExecuteReader();
            if (rslt.HasRows)
            {

                while (rslt.Read())
                {                   
                   jid = rslt["jid"].ToString();                    
                }
            }
            this.closeConnection();
            return jid;

        }
        public void openConnection()
        {
            if (myConn.State != System.Data.ConnectionState.Open)
            {
                myConn.Open();
            }
        }
        public void closeConnection()
        {

            if (myConn.State != System.Data.ConnectionState.Closed)
            {
                myConn.Close();
            }

        }

        private long convert(String number)
        {

            long num = Int64.Parse(number);
            return num ;
        }
        public List<Messages> listMessages(String key)
        {
            new Database();
            var liste = new List<Messages>();
            String query = "SELECT messages.key_from_me, status, messages.data, messages.timestamp, messages.media_url, messages.media_mime_type, messages.media_wa_type, messages.media_size, messages.media_name, messages.media_duration, messages.thumb_image FROM messages WHERE messages.key_remote_jid = @param ORDER BY messages.timestamp asc";
            SQLiteCommand myCmd = new SQLiteCommand(query, this.myConn);
            this.openConnection();
            myCmd.Parameters.Add(new SQLiteParameter("@param",key));
            SQLiteDataReader rslt = myCmd.ExecuteReader();
            if (rslt.HasRows)
            {

                while (rslt.Read())
                {

                    Messages msg = new Messages();
                    msg.setData(rslt["data"].ToString());
                    msg.setKey_from_me(Int32.Parse(rslt["key_from_me"].ToString()));
                    msg.setKey_remote_jid(key);
                    msg.setMedia_duration(Int32.Parse(rslt["media_duration"].ToString())) ;
                    msg.setMedia_mime_type(rslt["media_mime_type"].ToString());
                    msg.setMedia_name(rslt["media_name"].ToString());
                    msg.setMedia_size(Int32.Parse(rslt["media_size"].ToString()));
                    msg.setMedia_url(rslt["media_url"].ToString());
                    msg.setStatus(rslt["status"].ToString());
                    msg.setThumb_image(rslt["thumb_image"].ToString());
                    msg.setTimestamp(Int64.Parse(rslt["timestamp"].ToString()) );
                    msg.setMedia_wa_type(Int32.Parse(rslt["media_wa_type"].ToString())) ;
                    liste.Add(msg);
                }
            }
            this.closeConnection();
            return liste;
           
        }
        public List<ChatList> search(String m)
        {
            new Database();
            var liste = new List<ChatList>();
            String query = "SELECT chat_list._id as id ,chat_list.key_remote_jid, chat_list.subject, chat_list.creation, max(messages.timestamp) as max FROM chat_list  LEFT OUTER JOIN messages on messages.key_remote_jid = chat_list.key_remote_jid WHERE chat_list.key_remote_jid like @mc or chat_list.subject like @mc or messages.data like @mc GROUP BY chat_list.key_remote_jid, chat_list.subject, chat_list.creation ORDER BY max(messages.timestamp) desc";
            SQLiteCommand myCmd = new SQLiteCommand(query, this.myConn);
            myCmd.Parameters.Add(new SQLiteParameter("@mc", m));
            this.openConnection();
            SQLiteDataReader rslt = myCmd.ExecuteReader();
            if (rslt.HasRows)
            {

                while (rslt.Read())
                {

                    ChatList cl = new ChatList();
                    cl.setKey_remote_jid(rslt["key_remote_jid"].ToString());
                    cl.setId(rslt.GetDouble(0));
                    cl.setTimestamp(rslt.GetDouble(4));
                    //   if (rslt["creation"] != null )
                    //  {
                    //   cl.setCreation(rslt.GetFieldValue<double>(3)) ;
                    //  }
                    cl.setSubject(rslt["subject"].ToString());
                    liste.Add(cl);
                }
            }
            this.closeConnection();
            return liste;
        }
        public List<ChatList> listChat()
        {
            new Database();
            var liste = new List<ChatList>();
            String query = "SELECT chat_list._id as id ,chat_list.key_remote_jid, chat_list.subject, chat_list.creation, max(messages.timestamp) as max FROM chat_list LEFT OUTER JOIN messages on messages.key_remote_jid = chat_list.key_remote_jid  GROUP BY chat_list.key_remote_jid, chat_list.subject, chat_list.creation ORDER BY max(messages.timestamp) desc";
            SQLiteCommand myCmd = new SQLiteCommand(query, this.myConn);
            this.openConnection();
            SQLiteDataReader rslt = myCmd.ExecuteReader();
            if (rslt.HasRows)
            {

                while (rslt.Read())
                {

                    ChatList cl = new ChatList();
                    cl.setKey_remote_jid(rslt["key_remote_jid"].ToString());
                    cl.setId(rslt.GetDouble(0));
                    cl.setTimestamp(rslt.GetDouble(4));
                 //   if (rslt["creation"] != null )
                  //  {
                     //   cl.setCreation(rslt.GetFieldValue<double>(3)) ;
                  //  }
                    cl.setSubject(rslt["subject"].ToString());                                               
                    liste.Add(cl);
                }
            }
            this.closeConnection();
            return liste;

        }
    }


}
