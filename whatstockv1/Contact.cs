using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatstockv1
{
    class Contact
    {
        private String display_name, status, jid;
        private long number, status_timestamp, raw_contact_id;
        private int total;
        public int getTotal()
        {
            return total;
        }
        public String getJid()
        {
            return jid;
        }
        public void setJid(String jid)
        {
            this.jid = jid;
        }

        public Contact(String display_name, String status, long number, long status_timestamp, long raw_contact_id, String jid)
        {
            this.display_name = display_name;
            this.status = status;
            this.number = number;
            this.status_timestamp = status_timestamp;
            this.raw_contact_id = raw_contact_id;
            this.jid = jid;
        }
        public Contact()
        {
            this.display_name = "";
            this.status = "";
            this.number = 0;
            this.status_timestamp = 0;
            this.raw_contact_id = 0;
            this.jid = "";
        }
        public String getDisplay_name()
        {
            return display_name;
        }
        public void setDisplay_name(String display_name)
        {
            this.display_name = display_name;
        }
        public String getStatus()
        {
            return status;
        }
        public void setStatus(String status)
        {
            this.status = status;
        }
        public long getNumber()
        {
            return number;
        }

        public void setTotal(int t)
        {
            total = t;
        }

        public void setNumber(long number)
        {
            this.number = number;
        }
        public long getStatus_timestamp()
        {
            return status_timestamp;
        }
        public void setStatus_timestamp(long status_timestamp)
        {
            this.status_timestamp = status_timestamp;
        }
        public long getRaw_contact_id()
        {
            return raw_contact_id;
        }
        public void setRaw_contact_id(long raw_contact_id)
        {
            this.raw_contact_id = raw_contact_id;
        }
        public String toString()
        {
            return "Database [display_name=" + display_name + ", status=" + status + ", number=" + number
                    + ", status_timestamp=" + status_timestamp + ", raw_contact_id=" + raw_contact_id + "]";
        }





    }
}
