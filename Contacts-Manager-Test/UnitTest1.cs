using System;
using System.Collections.Generic;
using Xunit;
using Contacts_Manager;

namespace ContactsManagerTest
{
    public class ContactsTests
    {
        [Fact]
        public void Test_AddContact_Success()
        {
            // Arrange
            Contacts.contacts.Clear();
            string contact = "John Doe";

            // Act
            var result = Contacts.AddContact(contact);

            // Assert
            Assert.Contains(contact, result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void Test_RemoveContact_Success()
        {
            // Arrange
            Contacts.contacts.Clear();
            string contact = "Jane Doe";
            Contacts.AddContact(contact);

            // Act
            var result = Contacts.RemoveContact(contact);

            // Assert
            Assert.DoesNotContain(contact, result);
            Assert.Empty(result);
        }

        [Fact]
        public void Test_ViewAllContacts()
        {
            // Arrange
            Contacts.contacts.Clear();
            string contact1 = "John Doe";
            string contact2 = "Jane Doe";
            Contacts.AddContact(contact1);
            Contacts.AddContact(contact2);

            // Act
            var result = Contacts.ViewAllContacts();

            // Assert
            Assert.Contains(contact1, result);
            Assert.Contains(contact2, result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Test_AddContact_Duplicate()
        {
            // Arrange
            Contacts.contacts.Clear();
            string contact = "John Doe";
            Contacts.AddContact(contact);

            // Act
            var result = Record.Exception(() => Contacts.AddContact(contact));

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InvalidOperationException>(result);
            Assert.Equal("You cannot add duplicate contacts.", result.Message);
        }

        [Fact]
        public void Test_AddContact_EmptyOrWhitespace()
        {
            // Arrange
            Contacts.contacts.Clear();

            // Act
            var result = Record.Exception(() => Contacts.AddContact(" "));

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ArgumentException>(result);
            Assert.Equal("Contact cannot be empty or whitespace.", result.Message);
        }

        [Fact]
        public void Test_RemoveContact_NotExist()
        {
            // Arrange
            Contacts.contacts.Clear();
            string contact = "Non Existing Contact";

            // Act
            var result = Record.Exception(() => Contacts.RemoveContact(contact));

            // Assert
            Assert.NotNull(result);
            Assert.IsType<KeyNotFoundException>(result);
            Assert.Equal("Contact does not exist.", result.Message);
        }
    }
}
