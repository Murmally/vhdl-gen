library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity DES3_Sbox_architecture is
port (
	INPUT : in std_logic_vector(7 downto 0);
	OUTPUT: out std_logic_vector(7 downto 0));
end DES3_Sbox_architecture;

architecture ARCHITECTURE_NAME of DES3_Sbox_architecture is
begin
process (INPUT)
begin
	case INPUT is
		when "000000" => OUTPUT <= "1010";
		when "000001" => OUTPUT <= "1101";
		when "000010" => OUTPUT <= "0000";
		when "000011" => OUTPUT <= "0111";
		when "000100" => OUTPUT <= "1001";
		when "000101" => OUTPUT <= "0000";
		when "000110" => OUTPUT <= "1110";
		when "000111" => OUTPUT <= "1001";
		when "001000" => OUTPUT <= "0110";
		when "001001" => OUTPUT <= "0011";
		when "001010" => OUTPUT <= "0011";
		when "001011" => OUTPUT <= "0100";
		when "001100" => OUTPUT <= "1111";
		when "001101" => OUTPUT <= "0110";
		when "001110" => OUTPUT <= "0101";
		when "001111" => OUTPUT <= "1010";
		when "010000" => OUTPUT <= "0001";
		when "010001" => OUTPUT <= "0010";
		when "010010" => OUTPUT <= "1101";
		when "010011" => OUTPUT <= "1000";
		when "010100" => OUTPUT <= "1100";
		when "010101" => OUTPUT <= "0101";
		when "010110" => OUTPUT <= "0111";
		when "010111" => OUTPUT <= "1110";
		when "011000" => OUTPUT <= "1011";
		when "011001" => OUTPUT <= "1100";
		when "011010" => OUTPUT <= "0100";
		when "011011" => OUTPUT <= "1011";
		when "011100" => OUTPUT <= "0010";
		when "011101" => OUTPUT <= "1111";
		when "011110" => OUTPUT <= "1000";
		when "011111" => OUTPUT <= "0001";
		when "100000" => OUTPUT <= "1101";
		when "100001" => OUTPUT <= "0001";
		when "100010" => OUTPUT <= "0110";
		when "100011" => OUTPUT <= "1010";
		when "100100" => OUTPUT <= "0100";
		when "100101" => OUTPUT <= "1101";
		when "100110" => OUTPUT <= "1001";
		when "100111" => OUTPUT <= "0000";
		when "101000" => OUTPUT <= "1000";
		when "101001" => OUTPUT <= "0110";
		when "101010" => OUTPUT <= "1111";
		when "101011" => OUTPUT <= "1001";
		when "101100" => OUTPUT <= "0011";
		when "101101" => OUTPUT <= "1000";
		when "101110" => OUTPUT <= "0000";
		when "101111" => OUTPUT <= "0111";
		when "110000" => OUTPUT <= "1011";
		when "110001" => OUTPUT <= "0100";
		when "110010" => OUTPUT <= "0001";
		when "110011" => OUTPUT <= "1111";
		when "110100" => OUTPUT <= "0010";
		when "110101" => OUTPUT <= "1110";
		when "110110" => OUTPUT <= "1100";
		when "110111" => OUTPUT <= "0011";
		when "111000" => OUTPUT <= "0101";
		when "111001" => OUTPUT <= "1011";
		when "111010" => OUTPUT <= "1010";
		when "111011" => OUTPUT <= "0101";
		when "111100" => OUTPUT <= "1110";
		when "111101" => OUTPUT <= "0010";
		when "111110" => OUTPUT <= "0111";
		when "111111" => OUTPUT <= "1100";
		when others => OUTPUT <= "000000";
	end case;
end process;
end ARCHITECTURE_NAME;
