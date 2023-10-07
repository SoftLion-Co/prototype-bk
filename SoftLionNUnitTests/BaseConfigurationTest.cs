
using DAL.Context.Configurations.Base;
using DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftLionNUnitTests;

public class BaseConfigurationTest
{
    private readonly EntityTypeBuilder<BaseEntity> _entityTypeBuilder;

    private readonly BaseConfiguration<BaseEntity> _baseConfiguration;
    public BaseConfigurationTest()
    {
        _baseConfiguration = new BaseConfiguration<BaseEntity>();
        _entityTypeBuilder = new ModelBuilder().Entity<BaseEntity>();
    }
    [Test]
    public void BaseConfigurationPropertiesTest()
    {
        //Act
        _baseConfiguration.Configure(_entityTypeBuilder);
        var idProperty = _entityTypeBuilder.Metadata.FindProperty(nameof(BaseEntity.Id));
        var createdDateTimeProperty = _entityTypeBuilder.Metadata.FindProperty(nameof(BaseEntity.CreatedDateTime));
        var updatedDateTimeProperty = _entityTypeBuilder.Metadata.FindProperty(nameof(BaseEntity.UpdatedDateTime));
        
        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(idProperty, Is.Not.Null);
            Assert.That(idProperty, Is.Not.Null);
            Assert.That(idProperty, Is.Not.Null);
            Assert.That(idProperty!.IsKey, Is.True);
            Assert.That(idProperty.IsNullable, Is.False);
            Assert.That(createdDateTimeProperty!.IsNullable, Is.False);
            Assert.That(updatedDateTimeProperty!.IsNullable, Is.True);
        });

    }
}