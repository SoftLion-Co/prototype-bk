using DAL.Context.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftLionNUnitTests;

[TestFixture]
public class AuthorConfigurationTest
{
    private readonly AuthorConfiguration _authorConfiguration;

    private readonly EntityTypeBuilder<Author> _entityTypeBuilder;

    public AuthorConfigurationTest()
    {
        var modelBuilder = new ModelBuilder();
        _authorConfiguration = new AuthorConfiguration();
        _entityTypeBuilder = modelBuilder.Entity<Author>();
    }

    [Test]
    [TestCase("Author")]
    public void AuthorConfigurationCorrectTableNameTest(string tableName)
    {
        //Act
        _authorConfiguration.Configure(_entityTypeBuilder);
        
        //Assert
        Assert.That(_entityTypeBuilder.Metadata.GetTableName(), Is.EqualTo(tableName));
    }

    [Test]
    public void AuthorConfigurationCorrectPropertyConstraintsTest()
    {
        //Act
        _authorConfiguration.Configure(_entityTypeBuilder);
        var nameProperty = _entityTypeBuilder.Metadata.FindProperty(nameof(Author.Name));
        var surnameProperty  = _entityTypeBuilder.Metadata.FindProperty(nameof(Author.Surname));
        var employmentProperty = _entityTypeBuilder.Metadata.FindProperty(nameof(Author.Employment));
        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(nameProperty, Is.Not.Null);
            Assert.That(surnameProperty, Is.Not.Null);
            Assert.That(employmentProperty, Is.Not.Null);
            Assert.That(surnameProperty!.GetMaxLength(), Is.EqualTo(25));
            Assert.That(nameProperty!.GetMaxLength(), Is.EqualTo(25));
            Assert.That(employmentProperty!.GetMaxLength(), Is.EqualTo(50));
        });
    }

    [Test]
    public void AuthorConfigurationRelationsTest()
    {
        //Act
        _authorConfiguration.Configure(_entityTypeBuilder);
        var relationship = _entityTypeBuilder.Metadata.FindNavigation(nameof(Author.Blogs));
        
        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(relationship, Is.Not.Null);
            Assert.That(typeof(Blog), Is.EqualTo(relationship!.TargetEntityType.ClrType));
            Assert.That(relationship.ForeignKey.DeleteBehavior, Is.EqualTo(DeleteBehavior.Cascade));
        });
    }
}