namespace WpfApp1
{
    public abstract class Human
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public abstract void ShowAllUsers();
    }
}
