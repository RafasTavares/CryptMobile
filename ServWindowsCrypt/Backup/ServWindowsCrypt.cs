// Decompiled with JetBrains decompiler
// Type: ServWindowsCrypt
// Assembly: ServWindowsCrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03E49D0E-D978-421A-B097-95D8A04019A6
// Assembly location: D:\Projeto Mobile\mobile-windows\Componentes\ServWindowsCrypt.dll

public class ServWindowsCrypt
{
  public static string Encrypt(object textDescrypt)
  {
    return new Crypt("u1Js6MScyRtWNjPbyEDkmin3SWUKTroDRubU4RoEU20VN9fLk6cet6LF3dRWSKGdI7yBQd").Encrypt(textDescrypt.ToString());
  }

  public static string Decrypt(object textCrypt)
  {
    return new Crypt("u1Js6MScyRtWNjPbyEDkmin3SWUKTroDRubU4RoEU20VN9fLk6cet6LF3dRWSKGdI7yBQd").Decrypt(textCrypt.ToString());
  }
}
