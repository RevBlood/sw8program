using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IComment {
        [OperationContract]
        void AddComment(Comment com);
        [OperationContract]
        Comment GetCommentById(int comId);
        [OperationContract]
        void GetAllComments();
        [OperationContract]
        void DeleteComById(int comId);
    }
}
