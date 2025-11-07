namespace OoGuide.src;

public static class AsciiArt
{

    public static string GetAsciiModel(string type, string pos = "")
    {
        if (type.ToLower() == "sport")
        {
            return $@"
{pos}
{pos}.-'--`-._
{pos}'-O---O--'
";
        }
        else if (type.ToLower() == "passenger")
        {
            return $@"
{pos}   __
{pos} _| =\__
{pos}/o____o_\
";
        }
        else // Suv
        {
            return $@"
{pos}  ______
{pos} /|_||_\`.__
{pos}(   _    _ _\
{pos}=`-(_)--(_)-' 
";
        }
    }
}
