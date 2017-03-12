using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
        public override IQueryable<Product> All()
        {
            return base.Where(p => p.Stock < 1000 && p.IsDeleted == false);
        }
        public  IQueryable<Product> All( bool showall)
        {
            if (showall == true)
                return base.All();
            else
                return this.All();
        }
        public override void Delete(Product entity)
        {
            //�q Entity Framework ��������ҫ����Ҫ��覡
            //this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
            entity.IsDeleted = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}