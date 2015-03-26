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
        Comment GetCommentById(int commentId);
        [OperationContract]
        List<Comment> GetCommentsByRecipeId(int recipeId);
        [OperationContract]
        List<Comment> GetAllComments();
        [OperationContract]
        bool DeleteComById(int commentId);
    }
}
