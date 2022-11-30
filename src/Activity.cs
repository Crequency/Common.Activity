using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Material.Icons;

namespace Common.Activity
{
    public class Activity
    {
        /// <summary>
        /// 活动编号
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// 活动名称
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 活动图标
        /// </summary>
        public MaterialIconKind? IconKind { get; set; }
        
        /// <summary>
        /// 活动分类
        /// </summary>
        public string? Sort { get; set; }
        
        /// <summary>
        /// 活动标签
        /// </summary>
        public List<string>? Labels { get; set; }
        
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public List<DateTime>? StartTime { get; set; }
        
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public List<DateTime>? EndTime { get; set; }
        
        /// <summary>
        /// 活动进度
        /// </summary>
        public Progress? Progress { get; set; }
        
        /// <summary>
        /// 活动发起者 (包括重新发起者)
        /// </summary>
        public List<string>? Creator { get; set; }
        
        /// <summary>
        /// 活动执行人
        /// </summary>
        public List<string>? Assign { get; set; }
        
        /// <summary>
        /// 活动结束者 (包括再次结束者)
        /// </summary>
        public List<string>? Closer { get; set; }
        
        /// <summary>
        /// 活动标题
        /// </summary>
        public string? Title { get; set; }
        
        /// <summary>
        /// 活动任务
        /// </summary>
        public List<Task>? Tasks { get; set; }
        
        /// <summary>
        /// 活动结果
        /// </summary>
        public Result? Result { get; set; }
    }

    public enum Result
    {
        Unknown = 0, Success = 1, Warning = 2, Error = 3, Failed = 4, Waiting = 5
    }
}
