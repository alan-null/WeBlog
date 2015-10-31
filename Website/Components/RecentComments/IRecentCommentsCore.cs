using Sitecore.Modules.WeBlog.Items.WeBlog;

namespace Sitecore.Modules.WeBlog.Components.RecentComments
{
    public interface IRecentCommentsCore
    {
        CommentItem[] Comments { get; set; }
        string GetEntryUrlForComment(CommentItem commentItem);
        string GetEntryTitleForComment(CommentItem commentItem);
    }
}