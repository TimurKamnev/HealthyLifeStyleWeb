namespace ConsoleApp1
{
    public class Person
    {

        // создать класс 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        private string _gender; // поле

        public Person(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }



        public string GetGender()
        {
            return _gender;
        }

        public void SetGetnder(string gender)
        {
            _gender = gender;
        }

        public void Bite(Person person)
        {
            Console.WriteLine($"{Name} bit {person.Name}");
        }
    }
}
