﻿namespace NSupport.Test {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;

    public class DateTimeCalculationsTest {
        [Fact]
        public void Test_Tomorrow() {
            Assert.Equal(new DateTime(2010, 6, 15), new DateTime(2010, 6, 14).Tomorrow());
            Assert.Equal(new DateTime(2010, 6, 1), new DateTime(2010, 5, 31).Tomorrow()); // between months
            Assert.Equal(new DateTime(2011, 1, 1), new DateTime(2010, 12, 31).Tomorrow()); // between years
        }

        [Fact]
        public void Test_Yesterday() {
            Assert.Equal(new DateTime(2010, 6, 13), new DateTime(2010, 6, 14).Yesterday());
            Assert.Equal(new DateTime(2010, 5, 31), new DateTime(2010, 6, 1).Yesterday()); // between months
            Assert.Equal(new DateTime(2010, 12, 31), new DateTime(2011, 1, 1).Yesterday()); // between years
        }

        [Fact]
        public void Test_NextYear() {
            Assert.Equal(new DateTime(2011, 1, 14), new DateTime(2010, 1, 14).NextYear());
        }

        [Fact]
        public void Test_PreviousYear() {
            Assert.Equal(new DateTime(2009, 1, 14), new DateTime(2010, 1, 14).PreviousYear());
        }

        [Fact]
        public void Test_NextMonth() {
            Assert.Equal(new DateTime(2010, 2, 14), new DateTime(2010, 1, 14).NextMonth());
            Assert.Equal(new DateTime(2011, 1, 14), new DateTime(2010, 12, 14).NextMonth()); // between years
        }

        [Fact]
        public void Test_PreviousMonth() {
            Assert.Equal(new DateTime(2010, 1, 14), new DateTime(2010, 2, 14).PreviousMonth());
            Assert.Equal(new DateTime(2009, 12, 14), new DateTime(2010, 1, 14).PreviousMonth()); // between years
        }

        [Fact]
        public void Test_BeginningOfDay() {
            Assert.Equal(new DateTime(2011, 6, 14, 0, 0, 0), new DateTime(2011, 6, 14, 10, 0, 0).BeginningOfDay());
        }

        [Fact]
        public void Test_Midnight() {
            Assert.Equal(new DateTime(2011, 6, 14, 0, 0, 0), new DateTime(2011, 6, 14, 10, 0, 0).Midnight());
        }

        [Fact]
        public void Test_EndOfDay() {
            Assert.Equal(new DateTime(2011, 6, 14, 23, 59, 59), new DateTime(2011, 6, 14, 10, 0, 0).EndOfDay());
        }

        [Fact]
        public void Test_BeginningOfMonth() {
            Assert.Equal(new DateTime(2011, 6, 1, 0, 0, 0), new DateTime(2011, 6, 14, 10, 0, 0).BeginningOfMonth());
        }

        [Fact]
        public void Test_EndOfMonth() {
            Assert.Equal(new DateTime(2011, 6, 30, 23, 59, 59), new DateTime(2011, 6, 14, 10, 0, 0).EndOfMonth());
        }

        [Fact]
        public void Test_BeginningOfYear() {
            Assert.Equal(new DateTime(2011, 1, 1, 0, 0, 0), new DateTime(2011, 6, 14, 10, 0, 0).BeginningOfYear());
        }

        [Fact]
        public void Test_EndOfYear() {
            Assert.Equal(new DateTime(2011, 12, 31, 23, 59, 59), new DateTime(2011, 6, 14, 10, 0, 0).EndOfYear());
        }

        [Fact]
        public void Test_BeginningOfWeek() {
            Assert.Equal(new DateTime(2011, 6, 12, 0, 0, 0), new DateTime(2011, 6, 14, 10, 0, 0).BeginningOfWeek());
        }

        [Fact]
        public void Test_BeginningOfWeek_with_custom_FirstDayOfWeek_culture() {
            var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            var culture = new System.Globalization.CultureInfo("en-US", true);
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            Assert.Equal(new DateTime(2011, 6, 13, 0, 0, 0), new DateTime(2011, 6, 14, 10, 0, 0).BeginningOfWeek());

            System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture; // reset to currentCulture
        }

        [Fact]
        public void Test_EndOfWeek() {
            Assert.Equal(new DateTime(2011, 6, 18, 23, 59, 59), new DateTime(2011, 6, 14, 10, 0, 0).EndOfWeek());
        }

        [Fact]
        public void Test_EndOfWeek_with_custom_FirstDayOfWeek_culture() {
            var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            var culture = new System.Globalization.CultureInfo("en-US", true);
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            Assert.Equal(new DateTime(2011, 6, 19, 23, 59, 59), new DateTime(2011, 6, 14, 10, 0, 0).EndOfWeek());

            System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture; // reset to currentCulture
        }

        [Fact]
        public void Test_NextWeek() {
            Assert.Equal(new DateTime(2011, 6, 21, 0, 0, 0), new DateTime(2011, 6, 14, 10, 0, 0).NextWeek());
        }

        [Fact]
        public void Test_NextWeek_with_day() {
            Assert.Equal(new DateTime(2011, 6, 23, 0, 0, 0), new DateTime(2011, 6, 14, 10, 0, 0).NextWeek(day: DayOfWeek.Thursday));
        }

        [Fact]
        public void Test_BeginningOfQuarter() {
            // first quarter
            Assert.Equal(new DateTime(2011, 1, 1, 0, 0, 0), new DateTime(2011, 1, 14, 10, 0, 0).BeginningOfQuarter());
            Assert.Equal(new DateTime(2011, 1, 1, 0, 0, 0), new DateTime(2011, 2, 23, 10, 0, 0).BeginningOfQuarter());
            Assert.Equal(new DateTime(2011, 1, 1, 0, 0, 0), new DateTime(2011, 3, 31, 10, 0, 0).BeginningOfQuarter());
            
            // second quarter
            Assert.Equal(new DateTime(2011, 4, 1, 0, 0, 0), new DateTime(2011, 4, 14, 10, 0, 0).BeginningOfQuarter());
            Assert.Equal(new DateTime(2011, 4, 1, 0, 0, 0), new DateTime(2011, 5, 23, 10, 0, 0).BeginningOfQuarter());
            Assert.Equal(new DateTime(2011, 4, 1, 0, 0, 0), new DateTime(2011, 6, 30, 10, 0, 0).BeginningOfQuarter());

            // third quarter
            Assert.Equal(new DateTime(2011, 7, 1, 0, 0, 0), new DateTime(2011, 7, 14, 10, 0, 0).BeginningOfQuarter());
            Assert.Equal(new DateTime(2011, 7, 1, 0, 0, 0), new DateTime(2011, 8, 23, 10, 0, 0).BeginningOfQuarter());
            Assert.Equal(new DateTime(2011, 7, 1, 0, 0, 0), new DateTime(2011, 9, 30, 10, 0, 0).BeginningOfQuarter());

            // last quarter
            Assert.Equal(new DateTime(2011, 10, 1, 0, 0, 0), new DateTime(2011, 10, 14, 10, 0, 0).BeginningOfQuarter());
            Assert.Equal(new DateTime(2011, 10, 1, 0, 0, 0), new DateTime(2011, 11, 23, 10, 0, 0).BeginningOfQuarter());
            Assert.Equal(new DateTime(2011, 10, 1, 0, 0, 0), new DateTime(2011, 12, 31, 10, 0, 0).BeginningOfQuarter());
        }

        [Fact]
        public void Test_EndOfQuarter() {
            // first quarter
            Assert.Equal(new DateTime(2011, 3, 31, 23, 59, 59), new DateTime(2011, 1, 14, 10, 0, 0).EndOfQuarter());
            Assert.Equal(new DateTime(2011, 3, 31, 23, 59, 59), new DateTime(2011, 2, 23, 10, 0, 0).EndOfQuarter());
            Assert.Equal(new DateTime(2011, 3, 31, 23, 59, 59), new DateTime(2011, 3, 31, 10, 0, 0).EndOfQuarter());

            // second quarter
            Assert.Equal(new DateTime(2011, 6, 30, 23, 59, 59), new DateTime(2011, 4, 14, 10, 0, 0).EndOfQuarter());
            Assert.Equal(new DateTime(2011, 6, 30, 23, 59, 59), new DateTime(2011, 5, 23, 10, 0, 0).EndOfQuarter());
            Assert.Equal(new DateTime(2011, 6, 30, 23, 59, 59), new DateTime(2011, 6, 30, 10, 0, 0).EndOfQuarter());

            // third quarter
            Assert.Equal(new DateTime(2011, 9, 30, 23, 59, 59), new DateTime(2011, 7, 14, 10, 0, 0).EndOfQuarter());
            Assert.Equal(new DateTime(2011, 9, 30, 23, 59, 59), new DateTime(2011, 8, 23, 10, 0, 0).EndOfQuarter());
            Assert.Equal(new DateTime(2011, 9, 30, 23, 59, 59), new DateTime(2011, 9, 30, 10, 0, 0).EndOfQuarter());

            // last quarter
            Assert.Equal(new DateTime(2011, 12, 31, 23, 59, 59), new DateTime(2011, 10, 14, 10, 0, 0).EndOfQuarter());
            Assert.Equal(new DateTime(2011, 12, 31, 23, 59, 59), new DateTime(2011, 11, 23, 10, 0, 0).EndOfQuarter());
            Assert.Equal(new DateTime(2011, 12, 31, 23, 59, 59), new DateTime(2011, 12, 31, 10, 0, 0).EndOfQuarter());
        }

        [Fact]
        public void Test_IsToday() {
            Assert.Equal(true, DateTime.Now.IsToday());
            Assert.Equal(true, DateTime.Today.IsToday());

            Assert.Equal(false, new DateTime(2010, 1, 1).IsToday());
        }

        [Fact]
        public void Test_IsFuture() {
            Assert.Equal(true, DateTime.Now.AddDays(1).IsFuture());
            // single test should not longer than 5 seconds
            // if test is inconsistence, need to revisit this assert
            Assert.Equal(true, DateTime.Now.AddSeconds(5).IsFuture());

            Assert.Equal(false, DateTime.Now.IsFuture());
            Assert.Equal(false, DateTime.Today.IsFuture());
            Assert.Equal(false, new DateTime(2010, 1, 1).IsFuture());
        }
    }
}
