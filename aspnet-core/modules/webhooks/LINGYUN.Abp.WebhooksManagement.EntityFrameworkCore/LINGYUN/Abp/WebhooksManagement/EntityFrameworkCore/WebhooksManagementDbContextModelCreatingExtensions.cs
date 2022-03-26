﻿using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LINGYUN.Abp.WebhooksManagement.EntityFrameworkCore;

public static class WebhooksManagementDbContextModelCreatingExtensions
{
    public static void ConfigureWebhooksManagement(
        this ModelBuilder builder,
        Action<WebhooksManagementModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));

        var options = new WebhooksManagementModelBuilderConfigurationOptions(
            WebhooksManagementDbProperties.DbTablePrefix,
            WebhooksManagementDbProperties.DbSchema
        );
        optionsAction?.Invoke(options);

        builder.Entity<WebhookEventRecord>(b =>
        {
            b.ToTable(options.TablePrefix + "WebhookEvents", options.Schema);

            b.Property(p => p.WebhookName)
             .IsRequired()
             .HasColumnName(nameof(WebhookEventRecord.WebhookName))
             .HasMaxLength(WebhookEventRecordConsts.MaxWebhookNameLength);
            b.Property(p => p.Data)
             .HasColumnName(nameof(WebhookEventRecord.Data))
             .HasMaxLength(WebhookEventRecordConsts.MaxDataLength);

            b.ConfigureByConvention();
        });

        builder.Entity<WebhookSendRecord>(b =>
        {
            b.ToTable(options.TablePrefix + "WebhookSendAttempts", options.Schema);

            b.Property(p => p.Response)
             .HasColumnName(nameof(WebhookSendRecord.Response))
             .HasMaxLength(WebhookSendRecordConsts.MaxResponseLength);

            b.ConfigureByConvention();

            b.HasOne(p => p.WebhookEvent)
             .WithOne()
             .HasForeignKey<WebhookSendRecord>(fk => fk.WebhookEventId)
             .HasPrincipalKey<WebhookEventRecord>(pk => pk.Id );
        });

        builder.Entity<WebhookSubscription>(b =>
        {
            b.ToTable(options.TablePrefix + "WebhookSubscriptions", options.Schema);

            b.Property(p => p.WebhookUri)
             .IsRequired()
             .HasColumnName(nameof(WebhookSubscription.WebhookUri))
             .HasMaxLength(WebhookSubscriptionConsts.MaxWebhookUriLength);
            b.Property(p => p.Secret)
             .IsRequired()
             .HasColumnName(nameof(WebhookSubscription.Secret))
             .HasMaxLength(WebhookSubscriptionConsts.MaxSecretLength);

            b.Property(p => p.Webhooks)
             .HasColumnName(nameof(WebhookSubscription.Webhooks))
             .HasMaxLength(WebhookSubscriptionConsts.MaxWebhooksLength);
            b.Property(p => p.Headers)
             .HasColumnName(nameof(WebhookSubscription.Headers))
             .HasMaxLength(WebhookSubscriptionConsts.MaxHeadersLength);

            b.ConfigureByConvention();
        });
    }
}