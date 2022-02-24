using AutoMapper;


namespace  AutoMapperProfiles;


public class TestProfile : Profile
{
	public TestProfile()
	{
		CreateMap<FromTestClass, ToTestClass>()
          .ForMember(dest=>dest.MySub2,op=>op.MapFrom(src=>src.MySub));
		// Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
	}
}


public class Sub {
     public int MySubProperty { get; set; }
 } 

public class FromTestClass {
 public int MyInt { get; set; }
 public Guid MyGuid { get; set; }=Guid.NewGuid();
 public DateTime MyDateTime { get; set; }=DateTime.Now;

 

 public Sub? MySub { get; set; } //=new Sub () { MySubProperty=2 };


}



public class ToTestClass {
 public int MyInt { get; set; }
 public Guid MyGuid { get; set; }
 public DateTime MyDateTime { get; set; }=DateTime.Now;

 public Sub? MySub2 { get; set; }

}
