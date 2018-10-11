using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatstockv1
{
    class Messages_thumbnails : Messages
    {

        private String key_remote_jid, thumbnail;
        private double timestamp, key_from_me;

        public void setKey_remote_jid(String k)
        {
            this.key_remote_jid = k;
        }

    }
}
