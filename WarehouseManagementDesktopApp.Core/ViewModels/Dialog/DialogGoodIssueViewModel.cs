namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class DialogGoodIssueViewModel
{

    public static DialogGoodIssueViewModel Instance => new DialogGoodIssueViewModel();
    public ObservableCollection<ChatMessageListItemDesignModel> Items { get; set; }
    public DialogGoodIssueViewModel()
    {
        Items = new ObservableCollection<ChatMessageListItemDesignModel>
            {
                new ChatMessageListItemDesignModel
                {
                    SenderName = "Luke",
                    Initials = "LM",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.Now,
                    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemDesignModel
                {
                    SenderName = "Luke",
                    Initials = "LM",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.Now,
                    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemDesignModel
                {
                    SenderName = "Luke",
                    Initials = "LM",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.Now,
                    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemDesignModel
                {
                    SenderName = "Vương",
                    Initials = "LM",
                    Message = "Vương rớt đồ án",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.Now,
                    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemDesignModel
                {
                    SenderName = "Vương",
                    Initials = "LM",
                    Message = "Vương rớt đồ án",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.Now,
                    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemDesignModel
                {
                    SenderName = "Vương",
                    Initials = "LM",
                    Message = "Vương rớt đồ án",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.Now,
                    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemDesignModel
                {
                    SenderName = "Vương",
                    Initials = "LM",
                    Message = "Vương rớt đồ án",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.Now,
                    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemDesignModel
                {
                    SenderName = "Vương",
                    Initials = "LM",
                    Message = "Vương rớt đồ án",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.Now,
                    //MessageReadTime = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
            };
    }
}
