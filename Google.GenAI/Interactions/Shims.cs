// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

#if !NET
#pragma warning disable IDE0130 // Namespace does not match folder structure
#pragma warning disable CS9113 // Unused parameters

namespace System.Runtime.CompilerServices
{
    // Allow `required` to compile when targeting .NET Standard 2.0.
    [AttributeUsage(
        AttributeTargets.Class
            | AttributeTargets.Struct
            | AttributeTargets.Property
            | AttributeTargets.Field,
        AllowMultiple = false,
        Inherited = false
    )]
    internal sealed class RequiredMemberAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    internal sealed class CompilerFeatureRequiredAttribute : Attribute
    {
        public CompilerFeatureRequiredAttribute(string feature) { }
    }

    // Allow `init` to compile when targeting .NET Standard 2.0.
    internal static class IsExternalInit { }
}

namespace System.Diagnostics.CodeAnalysis
{
    // Allow `[SetsRequiredMembers]` to compile when targeting .NET Standard 2.0.
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    internal sealed class SetsRequiredMembersAttribute : Attribute { }

    // Allow `[MaybeNullWhen(...)]` to compile when targeting .NET Standard 2.0.
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class MaybeNullWhenAttribute : Attribute
    {
        public MaybeNullWhenAttribute(bool returnValue) { }
    }

    // Allow `[NotNullWhen(...)]` to compile when targeting .NET Standard 2.0.
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    internal sealed class NotNullWhenAttribute : Attribute
    {
        public NotNullWhenAttribute(bool returnValue) { }
    }
}
#endif
