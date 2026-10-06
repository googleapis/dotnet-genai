/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

// Auto-generated code. Do not edit.

using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json;

namespace Google.GenAI.Types {
  /// <summary>
  /// SafetyPolicy
  /// </summary>

  [JsonConverter(typeof(SafetyPolicyConverter))]
  public readonly record struct SafetyPolicy : IEquatable<SafetyPolicy> {
    public string Value { get; }

    private SafetyPolicy(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified safety policy. This value should not be used.
    /// </summary>
    public static SafetyPolicy SafetyPolicyUnspecified { get; } = new("SAFETY_POLICY_UNSPECIFIED");

    /// <summary>
    /// Financial transactions safety policy.
    /// </summary>
    public static SafetyPolicy FinancialTransactions { get; } = new("FINANCIAL_TRANSACTIONS");

    /// <summary>
    /// Sensitive data modification safety policy.
    /// </summary>
    public static SafetyPolicy SensitiveDataModification {
      get;
    } = new("SENSITIVE_DATA_MODIFICATION");

    /// <summary>
    /// Communication tool safety policy.
    /// </summary>
    public static SafetyPolicy CommunicationTool { get; } = new("COMMUNICATION_TOOL");

    /// <summary>
    /// Account creation safety policy.
    /// </summary>
    public static SafetyPolicy AccountCreation { get; } = new("ACCOUNT_CREATION");

    /// <summary>
    /// Data modification safety policy.
    /// </summary>
    public static SafetyPolicy DataModification { get; } = new("DATA_MODIFICATION");

    /// <summary>
    /// User consent management safety policy.
    /// </summary>
    public static SafetyPolicy UserConsentManagement { get; } = new("USER_CONSENT_MANAGEMENT");

    /// <summary>
    /// Legal terms and agreements safety policy.
    /// </summary>
    public static SafetyPolicy LegalTermsAndAgreements { get; } = new("LEGAL_TERMS_AND_AGREEMENTS");

    public static IReadOnlyList<SafetyPolicy> AllValues {
      get;
    } = new[] { SafetyPolicyUnspecified, FinancialTransactions,  SensitiveDataModification,
                CommunicationTool,       AccountCreation,        DataModification,
                UserConsentManagement,   LegalTermsAndAgreements };

    public static SafetyPolicy FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new SafetyPolicy("SAFETY_POLICY_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new SafetyPolicy(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator SafetyPolicy(string value) => FromString(value);

    public bool Equals(SafetyPolicy other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class SafetyPolicyConverter : JsonConverter<SafetyPolicy> {
    public override SafetyPolicy Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                      JsonSerializerOptions options) {
      var value = reader.GetString();
      return SafetyPolicy.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, SafetyPolicy value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
