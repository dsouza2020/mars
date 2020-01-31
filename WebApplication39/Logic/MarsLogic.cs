using MarsProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsProject.Logic
{
    public class MarsLogic
    {

        public static List<string>  AddPhotosToDatabase(List<PhotoObj> photoLists)
        {
            List<string> listOfUrls = new List<string>();
            using (var db = new MARSContext())
            {
                foreach(PhotoObj photo in photoLists)
                {
                    var newPhoto = new Photos();
                    var data = db.Photos.FirstOrDefault(x => x.Id == photo.id);
 
                    if(data == null)
                    {
                        newPhoto.Id = photo.id;
                        newPhoto.Sol = photo.sol;
                        newPhoto.ImgSrc = photo.img_src;
                        newPhoto.EarthDate = photo.earth_date.ToString();

                        listOfUrls.Add(photo.img_src);
                        db.Photos.Add(newPhoto);
                        db.SaveChanges();                    

                    }
                    else
                    {                      
                        data.Id = photo.id;
                        data.Sol = photo.sol;
                        data.ImgSrc = photo.img_src;
                        data.EarthDate = photo.earth_date.ToString();

                        listOfUrls.Add(photo.img_src);
                        db.Entry(data).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return listOfUrls;
            }         
        }

    }
}
