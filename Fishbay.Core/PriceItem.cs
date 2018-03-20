using System;
using Newtonsoft.Json;

namespace Fishbay.Core
{
    public class PriceItem
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public int SectionId { get; set; }
        public ItemState ItemState { get; set; }
        public string Name { get; set; }
        public string UnitType { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal SmallWholeSalePrice { get; set; }
        public decimal LargeWholeSalePrice { get; set; }
        public DateTime PriceDate { get; set; }
        public DateTime Created { get; set; }

    //[Id] [int] IDENTITY(1,1) NOT NULL,
	//[PartnerId] [int] NULL,
	//[SectionId] [int] NULL,
	//[ItemState] [int] NULL,
	//[Name] [nvarchar](128) NULL,
	//[UnitType] [nvarchar](16) NULL,
	//[RetailPrice] [money] NULL,
	//[SmallWholeSalePrice] [money] NULL,
	//[LargeWholeSalePrice] [money] NULL,
	//[PriceDate] [smalldatetime] NULL,
	//[Created] [datetime] NULL,
    }
}