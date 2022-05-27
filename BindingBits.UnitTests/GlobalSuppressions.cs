// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S1656:Variables should not be self-assigned", Justification = "Testing against no change in value.", Scope = "member", Target = "~M:BindingBits.UnitTests.ObservableObjectTests.SetWithBackingFieldShould.NotRaisePropertyChangedWhenBoolPropertyValueNotChangedFromDefault")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S1656:Variables should not be self-assigned", Justification = "Testing against no change in value.", Scope = "member", Target = "~M:BindingBits.UnitTests.ObservableObjectTests.SetWithNoBackingFieldShould.NotRaisePropertyChangedWhenBoolPropertyValueNotChangedFromDefault")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S1656:Variables should not be self-assigned", Justification = "Testing against no change in value.", Scope = "member", Target = "~M:BindingBits.UnitTests.ObservableObjectTests.SetWithNoBackingFieldShould.RaisePropertyChangedOnlyOnceWhenBoolPropertyValueSetTwiceButChangedOnce")]