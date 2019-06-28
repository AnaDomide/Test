using ExamenNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.ViewModels
{
    public class CommentGetModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? IdMovie { get; set; }    //accepta si valori null

        public bool Important { get; set; }

        public static CommentGetModel FromComment(Comment comment)
        {
            return new CommentGetModel
            {
                Id = comment.Id,
                Text = comment.Text,
                IdMovie = comment.Movie?.Id,  //evalueaza expresia daca comentariu.Film este null returneaza null, altfel evalueaza expresia si returneaza valoarea
                Important = comment.Important

                //IdFilm = comentariu.Film == null ? -1 : comentariu.Film.Id, //mod de a accepta ceva ce poate sa vina null

            };
        }
    }
}


