namespace cSharp_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(1101, "Omasa", "Male");
            Person person2 = new Person(1239, "Salma", "Female");
            Person person3 = new Person(1834, "Ahmed", "Male");
            Dictionary<long, Person> personMap = new Dictionary<long, Person>();
            //personMap.Add(person1.Id, person1);  //\Add method 1
            //personMap.Add(person2.Id, person2);
            //personMap.Add(person3.Id, person3);
            personMap[person1.Id] = person1; // Add method 2
            personMap [person2.Id] = person2;
            personMap [person3.Id] = person3;
            person1.Gender = "Female"; // Change the gender
            personMap[person1.Id] = person2; // Change something
            personMap.TryAdd(person1.Id, person1); // 
            Person? result = null;

            if (personMap.TryGetValue(person2.Id, out result))
            {
                Console.WriteLine(result);
            }
        }
    }
}