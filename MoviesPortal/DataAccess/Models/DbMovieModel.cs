using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models.Enums;

namespace DataAccess.Models
{
    public class DbMovieModel
    {
        public string Title { get; set; }

        public IList<DbCreativePersonModel> Director = new List<DbCreativePersonModel>();

        public int ProductionYear { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public bool IsForKids { get; set; }


        public IList<DbCreativePersonModel> ActorList = new List<DbCreativePersonModel>(); 

    }