/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "TrimLeadingWhitespaceRule.java".  Description:
  "Performs no validation but removes leading whitespace in the correct() method."

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2004.  All Rights Reserved.

  Contributor(s): ______________________________________.

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

namespace NHapi.Base.Validation.Implementation
{
    /// <summary>
    /// Performs no validation but removes leading whitespace in the correct() method.
    /// </summary>
    /// <author><a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a></author>
    /// <version>
    /// $Revision: 1.2 $ updated on $Date: 2005/06/14 20:16:01 $ by $Author: bryan_tripp $.
    /// </version>
    public class TrimLeadingWhitespace : IPrimitiveTypeRule
    {
        /// <summary>
        /// Gets the rule description.
        /// </summary>
        public virtual string Description => "Leading whitespace removed";

        /// <summary>
        /// Gets the section reference.
        /// </summary>
        public virtual string SectionReference => null;

        /// <inheritdoc />
        public virtual string correct(string originalValue)
        {
            return Correct(originalValue);
        }

        /// <inheritdoc />
        public virtual string Correct(string originalValue)
        {
            string trmValue = null;
            if (originalValue != null)
            {
                var stringChr = originalValue.ToCharArray();
                for (var i = 0; i < stringChr.Length && trmValue == null; i++)
                {
                    if (!char.IsWhiteSpace(stringChr[i]))
                    {
                        trmValue = new string(stringChr, i, stringChr.Length - i);
                    }
                }
            }

            return trmValue;
        }

        /// <inheritdoc />
        public virtual bool test(string value)
        {
            return Test(value);
        }

        /// <inheritdoc />
        public virtual bool Test(string value)
        {
            return true;
        }
    }
}