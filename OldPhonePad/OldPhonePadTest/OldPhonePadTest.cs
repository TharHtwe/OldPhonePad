using static OldPhonePadTranslator.OldPhonePadTranslator;

namespace OldPhonePadTest
{
    [TestClass]
    public sealed class OldPhonePadTest
    {
        [TestMethod]
        public void TestInputs()
        {
            // Invalids
            Assert.ThrowsException<InvalidDataException>(() => OldPhonePad(""));
            Assert.ThrowsException<InvalidDataException>(() => OldPhonePad("2233"));
            Assert.ThrowsException<InvalidDataException>(() => OldPhonePad("Hello World"));

            Assert.AreEqual("E", OldPhonePad("33#"));
            Assert.AreEqual("B", OldPhonePad("227*#"));
            Assert.AreEqual("HELLO", OldPhonePad("4433555 555666#"));
            Assert.AreEqual("TURING", OldPhonePad("8 88777444666*664#"));
            Assert.AreEqual("HI TURING", OldPhonePad("44 44408 88777444666*664#"));
            Assert.AreEqual("AB", OldPhonePad("2222222 22222#"));
        }
    }
}
