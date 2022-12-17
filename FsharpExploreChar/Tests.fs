(*
 Author: Mr. Jin Vincent N. Necesario | Philippines 

 These code have been prepared for educational purposes only. 
 Use at your own risk.

*)

namespace FsharpExploreChar.UnitTest

module FsharpExploreCharTypeTest = 

    open Xunit
    open Xunit.Abstractions
    open System 
    open System.Runtime.InteropServices

    type FsharpExploreCharTypeTest (output:ITestOutputHelper) =
        (*
            This example shows how to declare a character or System.Char type.
        *)
        [<Fact>]
        let ``Declare Character`` () = 
            let letter = 'A'
            Assert.IsType(typedefof<char>, letter)
    
        (*
            This example shows how to declare a character or System.Char type
            but by calling a function. 
        *)
        [<Fact>]
        let ``Declare Character By Calling A Function`` () = 
            let funcReturnChar () = 'E' 

            let vowel = funcReturnChar()
            Assert.IsType(typedefof<char>, vowel)

        (*
            This example prints emojis. Yehey!
            Output: 
            Unicode Character 'White Smiling Face' (U+263A) = '☺'
            Unicode Character 'Right-Facing Armenian Eternity Sign' (U+058D) = '֍'
        *)
        [<Fact>]
        let ``Print Characters`` () =
            (* a Unicode escape sequence, which is \u followed by the four-symbol hexadecimal representation of a character code. *)
            let smilingFace = '\u263A' (* ☺ *)
            let emoji1 = sprintf "Unicode Character 'White Smiling Face' (U+263A) = '%c'" smilingFace
            Assert.True(emoji1.Contains("☺"))
            output.WriteLine(emoji1)

            (* a Unicode escape sequence, which is \u followed by the four-symbol hexadecimal representation of a character code. *)
            let eternitySign = '\u058d'(* ֍ *)
            let emoji2 = sprintf "Unicode Character 'Right-Facing Armenian Eternity Sign' (U+058D) = '%c'" eternitySign
            Assert.True(emoji2.Contains("֍"))
            output.WriteLine(emoji2)
            
        
        [<Fact>]
        let ``Character Escape Sequences`` () = 
            
            let singleQuote = '\''

            Assert.True(singleQuote.ToString().Contains("'"))
            Assert.Equal(singleQuote, '\'')
            output.WriteLine(sprintf "Single Quote: %c" singleQuote)

            let doubleQuote = '\"'

            Assert.True(doubleQuote.ToString().Contains('"'))
            Assert.Equal(doubleQuote, '\"')
            output.WriteLine(sprintf "Double Quote: %c" doubleQuote)

            let backSlash = '\\'

            (* Both assert/checks are the same*)
            Assert.True(backSlash.ToString().Contains(@"\"))
            (* or *)
            Assert.True(backSlash.ToString().Contains("\\"))

            Assert.Equal(backSlash, '\\')
            output.WriteLine(sprintf "Backslash: %c" backSlash)

            let backSpace = '\b'

            Assert.True(backSpace.ToString().Contains("\b"))
            Assert.Equal(backSpace,'\b')
            output.WriteLine(sprintf "Backspace: %c" backSpace)

            let newline = '\n'

            Assert.True(newline.ToString().Contains("\n"))
            Assert.Equal(newline, '\n')
            output.WriteLine(sprintf "Newline: %c" newline)

            let carriageReturn = '\r'

            Assert.True(carriageReturn.ToString().Contains("\r"))
            Assert.Equal(carriageReturn, '\r')
            output.WriteLine(sprintf "Carriage Return: %c" carriageReturn)

            let horizontalTab = '\t'

            Assert.True(horizontalTab.ToString().Contains("\t"))
            Assert.Equal(horizontalTab, '\t')
            output.WriteLine(sprintf "Horizontal Tab: %c" horizontalTab)

        [<Fact>]
        let ``Character NewLine in Different Platform`` () =
        
            (* If you are inside a Unix similar operating system*)
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
               RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || 
               RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) then 
                
                let newline = '\n'

                Assert.Equal(newline, System.Environment.NewLine[0])
                output.WriteLine(sprintf "Linux Machine's ('\\n) %c is equals %c(Environment.NewLine[0])." newline Environment.NewLine[0])
            else (* Windows *) 
                
                let newline = "\r\n"
                Assert.Equal(newline, System.Environment.NewLine)
                output.WriteLine(sprintf "Windows Machine's ('\\r'\\n) %s is equals %s(Environment.NewLine)." newline System.Environment.NewLine)

        [<Fact>]
        let ``Numeric Representation of Character`` () = 
            let letterZ = 'Z'
           
            Assert.True(Char.IsAscii(letterZ))

            let numericalValue = (int letterZ)

            Assert.IsType(typedefof<int>, numericalValue)
            Assert.Equal(numericalValue, 90)



