using Microsoft.AspNetCore.Mvc;
using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class categoriesRepository
    {
        private readonly Datacontext _datacontext;

        public categoriesRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;

        }
        
        public List<categoriesModelList> categoriesList()
        {
            List<categoriesModelList> list = new List<categoriesModelList>();
            var data = _datacontext.categoriesMsts.ToList();
            {
                foreach(var item in data)
                {
                    categoriesModelList categoriesModelList = new categoriesModelList();
                    categoriesModelList.categoriesId = item.categoriesId;
                    categoriesModelList.categoriesName = item.categoriesName;
                    //categoriesModelList.categoriestatus = item.categoriestatus;
                    list.Add(categoriesModelList);  

                }
            }
            return list;
        }

        public void AddCategories(categoriesModelList categoriesModelList)
        {
            categoriesMst categories = new categoriesMst()
            {

                categoriesName = categoriesModelList.categoriesName
                //categoriestatus = categoriesModelList.categoriestatus
            };
            _datacontext.categoriesMsts.Add(categories);
            _datacontext.SaveChanges();

           
        }

        public void EditCategories(categoriesModelList categoriesModelList)
        {
            categoriesMst categories = new categoriesMst() { 
                categoriesId = categoriesModelList.categoriesId,
                categoriesName = categoriesModelList.categoriesName,
                //categoriestatus= categoriesModelList.categoriestatus

            };
            _datacontext.categoriesMsts.Update(categories);
            _datacontext.SaveChanges();

        }

        public void DeleteCategories(int id)
        {
            var data = _datacontext.categoriesMsts.Find(id);
            _datacontext.categoriesMsts.Remove(data);
            _datacontext.SaveChanges();
        }
        

       

    }
}
