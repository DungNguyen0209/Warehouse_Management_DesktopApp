using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    /// <summary>
    /// The design-time data for a <see cref="ChatMessageListViewModel"/>
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();
        public Action<string> RaiseClickEvent { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            #region item
            Items = new ObservableCollection<ChatMessageListItemDesignModel>();
            //Items = new ObservableCollection<ChatMessageListItemViewModel>
            //{
            //    //new ChatMessageListItemViewModel
            //    //{
            //    //    SenderName = "Luke",
            //    //    Initials = "LM",
            //    //    Message = "Let me know when you manage to spin up the new 2016 server",
            //    //    MessageSentTime = DateTimeOffset.Now,
            //    //    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
            //    //    ProfilePictureRGB = "3099c5",
            //    //    SentByMe = true,
            //    //},
            //    //new ChatMessageListItemViewModel
            //    //{
            //    //    SenderName = "Luke",
            //    //    Initials = "LM",
            //    //    Message = "Let me know when you manage to spin up the new 2016 server",
            //    //    ProfilePictureRGB = "3099c5",
            //    //    MessageSentTime = DateTimeOffset.Now,
            //    //    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
            //    //    SentByMe = true,
            //    //},
            //    //new ChatMessageListItemViewModel
            //    //{
            //    //    SenderName = "Luke",
            //    //    Initials = "LM",
            //    //    Message = "Let me know when you manage to spin up the new 2016 server",
            //    //    ProfilePictureRGB = "3099c5",
            //    //    MessageSentTime = DateTimeOffset.Now,
            //    //    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
            //    //    SentByMe = true,
            //    //},
            //    //new ChatMessageListItemViewModel
            //    //{
            //    //    SenderName = "Vương",
            //    //    Initials = "LM",
            //    //    Message = "Vương rớt đồ án",
            //    //    ProfilePictureRGB = "3099c5",
            //    //    MessageSentTime = DateTimeOffset.Now,
            //    //    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
            //    //    SentByMe = true,
            //    //},
            //    //new ChatMessageListItemViewModel
            //    //{
            //    //    SenderName = "Vương",
            //    //    Initials = "LM",
            //    //    Message = "Vương rớt đồ án",
            //    //    ProfilePictureRGB = "3099c5",
            //    //    MessageSentTime = DateTimeOffset.Now,
            //    //    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
            //    //    SentByMe = true,
            //    //},
            //    //new ChatMessageListItemViewModel
            //    //{
            //    //    SenderName = "Vương",
            //    //    Initials = "LM",
            //    //    Message = "Vương rớt đồ án",
            //    //    ProfilePictureRGB = "3099c5",
            //    //    MessageSentTime = DateTimeOffset.Now,
            //    //    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
            //    //    SentByMe = true,
            //    //},
            //    //new ChatMessageListItemViewModel
            //    //{
            //    //    SenderName = "Vương",
            //    //    Initials = "LM",
            //    //    Message = "Vương rớt đồ án",
            //    //    ProfilePictureRGB = "3099c5",
            //    //    MessageSentTime = DateTimeOffset.Now,
            //    //    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
            //    //    SentByMe = true,
            //    //},
            //    //new ChatMessageListItemViewModel
            //    //{
            //    //    SenderName = "Vương",
            //    //    Initials = "LM",
            //    //    Message = "Vương rớt đồ án",
            //    //    ProfilePictureRGB = "3099c5",
            //    //    MessageSentTime = DateTimeOffset.Now,
            //    //    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
            //    //    SentByMe = true,
            //    //},
            //};
            #endregion
            //foreach(var item in Items)
            //{
            //    item.ClickEvent += RaiseClickEvent;
            //}
        }

        #endregion
    }
}
