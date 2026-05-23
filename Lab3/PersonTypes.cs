namespace Lab3
{
    internal static class PersonTypes
    {
        public static void Initialize()
        {
            PersonFactory.Register("Sportsman",     () => new Sportsman());
            PersonFactory.Register("Boxer",         () => new Boxer());
            PersonFactory.Register("FootbalPlayer", () => new FootbalPlayer());
            PersonFactory.Register("Jumper",        () => new Jumper());
            PersonFactory.Register("Skater",        () => new Skater());
            PersonFactory.Register("Swimmer",       () => new Swimmer());
        }
    }
}
