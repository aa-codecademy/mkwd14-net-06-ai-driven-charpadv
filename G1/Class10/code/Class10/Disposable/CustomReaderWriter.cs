

internal class OurWriter : IDisposable
{
    private string _path;

    private readonly StreamWriter _writer;

    private bool _disposed;

    public OurWriter(string filePath)
    {
        _path = filePath;
        _writer = new StreamWriter(filePath, append: true);
    }

    public void Write(string text)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException("OurWriter is disposed.");
        }
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentNullException("Must provide valid text value");
        }
        _writer.WriteLine(text);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _writer.Dispose();
            }
            _path = string.Empty;
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

internal class OurReader : IDisposable
{
    private string _path;

    private StreamReader _sr;

    private bool _disposedValue = false;

    public OurReader(string filePath)
    {
        _path = filePath;
        _sr = new StreamReader(_path);
    }

    public string Read()
    {
        return _sr.ReadToEnd();
    }

    #region Dispose Implementation
    // We implement this private method that will remember when this class is disposed
    // That way, if the same class tries to get disposed again, all the Dispose() methods will not get called
    private void Dispose(bool disposing)
    {
        // This happens only when the class needs to be disposed the first time
        if (!_disposedValue)
        {
            if (disposing)
            {
                _sr.Dispose();
            }

            _path = string.Empty;
            _disposedValue = true;
        }
    }

    // We can implement this method alone and add the disposing here
    public void Dispose()
    {
        Dispose(true);
    }
    #endregion
}