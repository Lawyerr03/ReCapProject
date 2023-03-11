using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult< List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>> (_colorDal.GetAll(),Messeges.ColorListed);
        }

        public IDataResult <Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color> (_colorDal.Get(o=> o.ColorId == colorId)); 
        }
    }
}
