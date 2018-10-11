using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatstockv1
{
    class Messages
    {
        private String key_remote_jid, data, status, media_url, thumb_image, media_mime_type, media_name;
        private int media_wa_type, key_from_me, media_size, media_duration;
        private long timestamp;



        public Messages(String key_remote_jid, String data, String status, String media_url, String thumb_image,
                String media_mime_type, String media_name, int media_wa_type, int key_from_me, long timestamp,
                int media_size, int media_duration)
        {

            this.key_remote_jid = key_remote_jid;
            this.data = data;
            this.status = status;
            this.media_url = media_url;
            this.thumb_image = thumb_image;
            this.media_mime_type = media_mime_type;
            this.media_name = media_name;
            this.media_wa_type = media_wa_type;
            this.key_from_me = key_from_me;
            this.timestamp = timestamp;
            this.media_size = media_size;
            this.media_duration = media_duration;
        }
        public Messages()
        {
            this.key_remote_jid = "";
            this.data = "";
            this.status = "";
            this.media_url = "";
            this.thumb_image = "";
            this.media_mime_type = "";
            this.media_name = "";
            this.media_wa_type = -1;
            this.key_from_me = -1;
            this.timestamp = -1;
            this.media_size = -1;
            this.media_duration = -1;

        }

        internal Contact appartient
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public String toString()
        {
            return "Message [key_remote_jid=" + key_remote_jid + ", data=" + data + ", status=" + status + ", media_url="
                    + media_url + ", thumb_image=" + thumb_image + ", media_mime_type=" + media_mime_type + ", media_name="
                    + media_name + ", media_wa_type=" + media_wa_type + ", key_from_me=" + key_from_me + ", timestamp="
                    + timestamp + ", media_size=" + media_size + ", media_duration=" + media_duration + "]";
        }
        public String getKey_remote_jid()
        {
            return key_remote_jid;
        }
        public void setKey_remote_jid(String key_remote_jid)
        {
            this.key_remote_jid = key_remote_jid;
        }
        public String getData()
        {
            return data;
        }
        public void setData(String data)
        {
            this.data = data;
        }
        public String getStatus()
        {
            return status;
        }
        public void setStatus(String status)
        {
            this.status = status;
        }
        public String getMedia_url()
        {
            return media_url;
        }
        public void setMedia_url(String media_url)
        {
            this.media_url = media_url;
        }
        public String getThumb_image()
        {
            return thumb_image;
        }
        public void setThumb_image(String thumb_image)
        {
            this.thumb_image = thumb_image;
        }
        public String getMedia_mime_type()
        {
            return media_mime_type;
        }
        public void setMedia_mime_type(String media_mime_type)
        {
            this.media_mime_type = media_mime_type;
        }
        public String getMedia_name()
        {
            return media_name;
        }
        public void setMedia_name(String media_name)
        {
            this.media_name = media_name;
        }
        public int getMedia_wa_type()
        {
            return media_wa_type;
        }
        public void setMedia_wa_type(int media_wa_type)
        {
            this.media_wa_type = media_wa_type;
        }
        public int getKey_from_me()
        {
            return key_from_me;
        }
        public void setKey_from_me(int key_from_me)
        {
            this.key_from_me = key_from_me;
        }
        public long getTimestamp()
        {
            return timestamp;
        }
        public void setTimestamp(long timestamp)
        {
            this.timestamp = timestamp;
        }
        public int getMedia_size()
        {
            return media_size;
        }
        public void setMedia_size(int media_size)
        {
            this.media_size = media_size;
        }
        public int getMedia_duration()
        {
            return media_duration;
        }
        public void setMedia_duration(int media_duration)
        {
            this.media_duration = media_duration;
        }


    }
}

