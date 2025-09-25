namespace MyPlanner2.src;

/// <summary>
/// This interface describes a FileHandler that reads and writes to
/// a file.
/// </summary>
public interface IFileHandler
{
    /// <summary>
    /// Reads all the lines in the file specified when object is
    /// created.
    /// </summary>
    /// <returns>An array of strings containing the content of the file.</returns>
    string[] Read();

    /// <summary>
    /// Saves all the 
    /// </summary>
    /// <param name="lines">An array of strings that should be saved to the file.</param>
    void Save(string[] lines);
}
