library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity FunctionGShift is
port (
	INPUT : in std_logic_vector(0 to 31);
	OUTPUT: out std_logic_vector(0 to 31));
end FunctionGShift;

architecture FunctionGShift_architecture of FunctionGShift is
begin
	OUTPUT(0) <= INPUT(24);
	OUTPUT(1) <= INPUT(25);
	OUTPUT(2) <= INPUT(26);
	OUTPUT(3) <= INPUT(27);
	OUTPUT(4) <= INPUT(28);
	OUTPUT(5) <= INPUT(29);
	OUTPUT(6) <= INPUT(30);
	OUTPUT(7) <= INPUT(31);
	OUTPUT(8) <= INPUT(0);
	OUTPUT(9) <= INPUT(1);
	OUTPUT(10) <= INPUT(2);
	OUTPUT(11) <= INPUT(3);
	OUTPUT(12) <= INPUT(4);
	OUTPUT(13) <= INPUT(5);
	OUTPUT(14) <= INPUT(6);
	OUTPUT(15) <= INPUT(7);
	OUTPUT(16) <= INPUT(8);
	OUTPUT(17) <= INPUT(9);
	OUTPUT(18) <= INPUT(10);
	OUTPUT(19) <= INPUT(11);
	OUTPUT(20) <= INPUT(12);
	OUTPUT(21) <= INPUT(13);
	OUTPUT(22) <= INPUT(14);
	OUTPUT(23) <= INPUT(15);
	OUTPUT(24) <= INPUT(16);
	OUTPUT(25) <= INPUT(17);
	OUTPUT(26) <= INPUT(18);
	OUTPUT(27) <= INPUT(19);
	OUTPUT(28) <= INPUT(20);
	OUTPUT(29) <= INPUT(21);
	OUTPUT(30) <= INPUT(22);
	OUTPUT(31) <= INPUT(23);
end FunctionGShift_architecture;
