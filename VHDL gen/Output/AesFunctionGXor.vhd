library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity FunctionGXor is
port (
	INPUT1 : in std_logic_vector(31 downto 0);
	INPUT2 : in std_logic_vector(31 downto 0);
	OUTPUT: out std_logic_vector(31 downto 0));
end FunctionGXor;

architecture FunctionGXor_architecture of FunctionGXor is
begin
    OUTPUT <= INPUT1 XOR INPUT2;
end FunctionGXor_architecture;
