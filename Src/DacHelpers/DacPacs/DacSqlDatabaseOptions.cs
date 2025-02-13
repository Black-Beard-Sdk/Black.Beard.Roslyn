﻿using System.Xml.Linq;

namespace Bb.DacPacs
{

    public class DacSqlDatabaseOptions : DacElement
    {

        public DacSqlDatabaseOptions() : base(ElementTypePropertyValue.SqlDatabaseOptions)
        {

            this.Collation = CollationPropertyValue.SQL_Latin1_General_CP1_CI_AS;
            this.IsAnsiNullDefaultOn = BooleanPropertyValue.True;
            this.IsAnsiNullsOn = BooleanPropertyValue.True;
            this.IsAnsiWarningsOn = BooleanPropertyValue.True;
            this.IsArithAbortOn = BooleanPropertyValue.True;
            this.IsConcatNullYieldsNullOn = BooleanPropertyValue.True;
            this.IsTornPageProtectionOn = BooleanPropertyValue.False;
            this.IsFullTextEnabled = BooleanPropertyValue.True;
            this.PageVerifyMode = 3;
            this.DefaultLanguage = string.Empty;
            this.DefaultFullTextLanguage = String.Empty;
            this.QueryStoreStaleQueryThreshold = 367;

            this.DefaultFilegroup.Entry(e => e.References("[PRIMARY]", "BuiltIns"));

        }

        public CollationPropertyValue Collation
        {
            get => Properties.Resolve("Collation").GetValue<CollationPropertyValue>();
            set => Properties.Resolve("Collation").SetValue(value);
        }

        public BooleanPropertyValue IsAnsiNullDefaultOn
        {
            get => Properties.Resolve("IsAnsiNullDefaultOn").GetValue<BooleanPropertyValue>();
            set => Properties.Resolve("IsAnsiNullDefaultOn").SetValue(value);
        }

        public BooleanPropertyValue IsAnsiNullsOn
        {
            get => Properties.Resolve("IsAnsiNullsOn").GetValue<BooleanPropertyValue>();
            set => Properties.Resolve("IsAnsiNullsOn").SetValue(value);
        }

        public BooleanPropertyValue IsAnsiWarningsOn
        {
            get => Properties.Resolve("IsAnsiWarningsOn").GetValue<BooleanPropertyValue>();
            set => Properties.Resolve("IsAnsiWarningsOn").SetValue(value);
        }

        public BooleanPropertyValue IsArithAbortOn
        {
            get => Properties.Resolve("IsArithAbortOn").GetValue<BooleanPropertyValue>();
            set => Properties.Resolve("IsArithAbortOn").SetValue(value);
        }

        public BooleanPropertyValue IsConcatNullYieldsNullOn
        {
            get => Properties.Resolve("IsConcatNullYieldsNullOn").GetValue<BooleanPropertyValue>();
            set => Properties.Resolve("IsConcatNullYieldsNullOn").SetValue(value);
        }

        public BooleanPropertyValue IsTornPageProtectionOn
        {
            get => Properties.Resolve("IsTornPageProtectionOn").GetValue<BooleanPropertyValue>();
            set => Properties.Resolve("IsTornPageProtectionOn").SetValue(value);
        }

        public BooleanPropertyValue IsFullTextEnabled
        {
            get => Properties.Resolve("IsFullTextEnabled").GetValue<BooleanPropertyValue>();
            set => Properties.Resolve("IsFullTextEnabled").SetValue(value);
        }

        public IntPropertyValue PageVerifyMode
        {
            get => Properties.Resolve("PageVerifyMode").GetValue<IntPropertyValue>();
            set => Properties.Resolve("PageVerifyMode").SetValue(value);
        }

        public IntPropertyValue QueryStoreStaleQueryThreshold
        {
            get => Properties.Resolve("QueryStoreStaleQueryThreshold").GetValue<IntPropertyValue>();
            set => Properties.Resolve("QueryStoreStaleQueryThreshold").SetValue(value);
        }

        public StringPropertyValue DefaultLanguage
        {
            get => Properties.Resolve("DefaultLanguage").GetValue<StringPropertyValue>();
            set => Properties.Resolve("DefaultLanguage").SetValue(value);
        }

        public StringPropertyValue DefaultFullTextLanguage
        {
            get => Properties.Resolve("DefaultFullTextLanguage").GetValue<StringPropertyValue>();
            set => Properties.Resolve("DefaultFullTextLanguage").SetValue(value);
        }

        public DacRelationship DefaultFilegroup
        {
            get => Relationships.Resolve(RelationshipNamePropertyValue.DefaultFilegroup);
        }

    }



}
