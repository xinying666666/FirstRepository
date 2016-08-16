using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CarManager.Core.Domain;
using CarManager.Web.Models.Cars;

namespace CarManager.Web.MVC
{
    public class AutoMapperProfile:Profile
    {
        private const string MvnViewModelSuffixName = "ViewModel";
        protected override void Configure()
        {
            //base.Configure();
            this.CreateMap<Car, CarViewModel>();
            this.CreateMap< CarViewModel,Car>();

            //查找以ViewModel 结尾的类型名
            var vidwModelTypes = this.GetType().Assembly.GetTypes().Where(t=>t.Name.EndsWith(MvnViewModelSuffixName));
            //查找db的类型
            var domainTypes = typeof(BaseEntity).Assembly.GetTypes();
            foreach (Type modelType in vidwModelTypes)
            {
                var modelTypeRelationDomainType = domainTypes.SingleOrDefault(dt=>dt.Name+ MvnViewModelSuffixName== modelType.Name);

                if (modelTypeRelationDomainType!=null)
                {
                    this.CreateMap(modelType, modelTypeRelationDomainType);
                    //MaxDepth最多检查深度为10 防止死循环
                    this.CreateMap(modelTypeRelationDomainType,modelType).MaxDepth(10);

                }
            }

        }


    }
}