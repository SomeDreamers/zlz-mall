namespace Pls.Entity
{
    public class NoticeInfo : PageEntity
    {
		/// <summary>
		/// 公告内容
		/// </summary>
		public string notice_desc { get; set; }

		/// <summary>
		/// (默认否:false) 是否禁用(管理员设置)
		/// </summary>
		public int disable { get; set; } = (int)DisableStatus.disable_false;
	}
}
