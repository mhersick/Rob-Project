//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E3DBPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class BlogPost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BlogPost()
        {
            this.BlogComments = new HashSet<BlogComment>();
        }
    
        public int PostID { get; set; }
        public int Post_CategoryID { get; set; }
        public string Post_author { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime Post_Date { get; set; }
        public string Post_Tite { get; set; }
        public string Post_Content { get; set; }
        public string Post_Status { get; set; }
        public bool Post_Deleted { get; set; }
        public bool Post_Active { get; set; }
        public bool Post_Featured { get; set; }
        public Nullable<int> Post_Views { get; set; }
        public bool Post_CommentsAllowed { get; set; }
        public string Post_Image1 { get; set; }
        public string Post_Image2 { get; set; }
        public string Post_Image3 { get; set; }
        public string Post_Banner1 { get; set; }
        public string Post_Article { get; set; }
        public string Post_ArticleContent { get; set; }
        public string Post_URL1 { get; set; }
        public string Post_URL2 { get; set; }
        public bool Post_CommentsReview { get; set; }
    
        public virtual BlogCategory BlogCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogComment> BlogComments { get; set; }
    }
}
