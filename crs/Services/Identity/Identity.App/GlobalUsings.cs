﻿global using FluentValidation;
global using Identity.App;
global using Identity.App.OptionsSetup;
global using Identity.Infrastructure.Authentication;
global using Identity.Infrastructure.BackgroundJobs;
global using Identity.Infrastructure.Email;
global using Identity.Infrastructure.Idempotence;
global using Identity.Persistence;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Quartz;
global using Common.App.Extensions;
global using Common.App.Options;
global using Common.Application.Behaviors;
global using System.Reflection;
global using System.Text;
global using Asp.Versioning;
global using Common.Infrastructure.Middleware;
global using System.Security.Claims;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using OpenTelemetry.Metrics;
global using Prometheus;
global using Common.App.HealthChecks;
global using MassTransit;
global using EventBus.Common.Abstractions;
global using EventBus.MassTransit.RabbitMQ.Services;
