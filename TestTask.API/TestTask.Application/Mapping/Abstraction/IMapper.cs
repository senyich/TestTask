namespace TestTask.Application.Mapping.Abstraction;

public interface IMapper<T1,T2> 
    where T1 : class 
    where T2 : class
{
    T1 Map(T2 obj);
}