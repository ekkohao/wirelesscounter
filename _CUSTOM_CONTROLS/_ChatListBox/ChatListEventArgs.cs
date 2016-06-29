using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace _CUSTOM_CONTROLS._ChatListBox2
{
    //自定义事件参数类
    public class ChatListEventArgs
    {
        private ChatListSubItem mouseOnSubItem;
        public ChatListSubItem MouseOnSubItem {
            get { return mouseOnSubItem; }
        }

        private ChatListSubItem selectSubItem;
        public ChatListSubItem SelectSubItem {
            get { return selectSubItem; }
        }
        private ChatListItem selectItem;
        public ChatListItem SelectItem
        {
            get { return selectItem; }
        }
        private MouseButtons button;
        public MouseButtons Button
        {
            get { return button; }
        }

        public ChatListEventArgs(ChatListSubItem mouseonsubitem, ChatListSubItem selectsubitem) {
            this.mouseOnSubItem = mouseonsubitem;
            this.selectSubItem = selectsubitem;
        }
        public ChatListEventArgs(ChatListSubItem mouseonsubitem, ChatListSubItem selectsubitem,MouseButtons button)
        {
            this.mouseOnSubItem = mouseonsubitem;
            this.selectSubItem = selectsubitem;
            this.button = button;
        }
        public ChatListEventArgs(ChatListSubItem mouseonsubitem, ChatListItem selectitem, MouseButtons button)
        {
            this.mouseOnSubItem = mouseonsubitem;
            this.selectItem = selectitem;
            this.button = button;
        }
    }
}
