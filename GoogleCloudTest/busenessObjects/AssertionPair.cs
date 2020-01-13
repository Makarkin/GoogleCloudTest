﻿using System;

namespace GoogleCloudTest.busenessObjects
{
    class AssertionPair
    {
        private String variable;
        private String value;

        public AssertionPair(String variable, String value)
        {
            this.variable = variable;
            this.value = value;
        }

        public String getVariable()
        {
            return variable;
        }

        public void setVariable(String variable)
        {
            this.variable = variable;
        }

        public String getValue()
        {
            return value;
        }

        public void setValue(String value)
        {
            this.value = value;
        }
    }
}
