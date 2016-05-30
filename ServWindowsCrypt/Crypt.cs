// Decompiled with JetBrains decompiler
// Type: Crypt
// Assembly: ServWindowsCrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03E49D0E-D978-421A-B097-95D8A04019A6
// Assembly location: D:\Projeto Mobile\mobile-windows\Componentes\ServWindowsCrypt.dll

using System;
using System.Security.Cryptography;
using System.Text;

public class Crypt
{
  private static readonly byte[] IV = new byte[16]
  {
    (byte) 2,
    (byte) 254,
    (byte) 242,
    (byte) 42,
    (byte) 69,
    (byte) 199,
    (byte) 205,
    (byte) 249,
    (byte) 5,
    (byte) 70,
    (byte) 156,
    (byte) 234,
    (byte) 168,
    (byte) 75,
    (byte) 115,
    (byte) 204
  };
  private readonly ICryptoTransform _decryptor;
  private readonly ICryptoTransform _encryptor;
  private readonly byte[] _password;
  private readonly RijndaelManaged _cipher;

  private ICryptoTransform Decryptor
  {
    get
    {
      return this._decryptor;
    }
  }

  private ICryptoTransform Encryptor
  {
    get
    {
      return this._encryptor;
    }
  }

  public Crypt(string password)
  {
    this._password = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password));
    this._cipher = new RijndaelManaged();
    this._decryptor = this._cipher.CreateDecryptor(this._password, Crypt.IV);
    this._encryptor = this._cipher.CreateEncryptor(this._password, Crypt.IV);
  }

  public string Decrypt(string text)
  {
    try
    {
      byte[] inputBuffer = Convert.FromBase64String(text);
      return Encoding.ASCII.GetString(this.Decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
    }
    catch (ArgumentException ex)
    {
      Console.WriteLine("inputCount uses an invalid value or inputBuffer has an invalid offset length. " + (object) ex);
      return (string) null;
    }
    catch (ObjectDisposedException ex)
    {
      Console.WriteLine("The object has already been disposed." + (object) ex);
      return (string) null;
    }
  }

  public string Encrypt(string text)
  {
    try
    {
      byte[] bytes = Encoding.ASCII.GetBytes(text);
      return Convert.ToBase64String(this.Encryptor.TransformFinalBlock(bytes, 0, bytes.Length));
    }
    catch (ArgumentException ex)
    {
      Console.WriteLine("inputCount uses an invalid value or inputBuffer has an invalid offset length. " + (object) ex);
      return (string) null;
    }
    catch (ObjectDisposedException ex)
    {
      Console.WriteLine("The object has already been disposed." + (object) ex);
      return (string) null;
    }
  }
}
