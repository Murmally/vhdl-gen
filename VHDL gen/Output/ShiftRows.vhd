library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity ShiftRows is
port (
	INPUT : in std_logic_vector(0 to 127);
	OUTPUT: out std_logic_vector(0 to 127));
end ShiftRows;

architecture ShiftRows_architecture of ShiftRows is
begin
	OUTPUT(0) <= INPUT(0);
	OUTPUT(1) <= INPUT(1);
	OUTPUT(2) <= INPUT(2);
	OUTPUT(3) <= INPUT(3);
	OUTPUT(4) <= INPUT(4);
	OUTPUT(5) <= INPUT(5);
	OUTPUT(6) <= INPUT(6);
	OUTPUT(7) <= INPUT(7);
	OUTPUT(104) <= INPUT(8);
	OUTPUT(105) <= INPUT(9);
	OUTPUT(106) <= INPUT(10);
	OUTPUT(107) <= INPUT(11);
	OUTPUT(108) <= INPUT(12);
	OUTPUT(109) <= INPUT(13);
	OUTPUT(110) <= INPUT(14);
	OUTPUT(111) <= INPUT(15);
	OUTPUT(80) <= INPUT(16);
	OUTPUT(81) <= INPUT(17);
	OUTPUT(82) <= INPUT(18);
	OUTPUT(83) <= INPUT(19);
	OUTPUT(84) <= INPUT(20);
	OUTPUT(85) <= INPUT(21);
	OUTPUT(86) <= INPUT(22);
	OUTPUT(87) <= INPUT(23);
	OUTPUT(56) <= INPUT(24);
	OUTPUT(57) <= INPUT(25);
	OUTPUT(58) <= INPUT(26);
	OUTPUT(59) <= INPUT(27);
	OUTPUT(60) <= INPUT(28);
	OUTPUT(61) <= INPUT(29);
	OUTPUT(62) <= INPUT(30);
	OUTPUT(63) <= INPUT(31);
	OUTPUT(32) <= INPUT(32);
	OUTPUT(33) <= INPUT(33);
	OUTPUT(34) <= INPUT(34);
	OUTPUT(35) <= INPUT(35);
	OUTPUT(36) <= INPUT(36);
	OUTPUT(37) <= INPUT(37);
	OUTPUT(38) <= INPUT(38);
	OUTPUT(39) <= INPUT(39);
	OUTPUT(8) <= INPUT(40);
	OUTPUT(9) <= INPUT(41);
	OUTPUT(10) <= INPUT(42);
	OUTPUT(11) <= INPUT(43);
	OUTPUT(12) <= INPUT(44);
	OUTPUT(13) <= INPUT(45);
	OUTPUT(14) <= INPUT(46);
	OUTPUT(15) <= INPUT(47);
	OUTPUT(112) <= INPUT(48);
	OUTPUT(113) <= INPUT(49);
	OUTPUT(114) <= INPUT(50);
	OUTPUT(115) <= INPUT(51);
	OUTPUT(116) <= INPUT(52);
	OUTPUT(117) <= INPUT(53);
	OUTPUT(118) <= INPUT(54);
	OUTPUT(119) <= INPUT(55);
	OUTPUT(88) <= INPUT(56);
	OUTPUT(89) <= INPUT(57);
	OUTPUT(90) <= INPUT(58);
	OUTPUT(91) <= INPUT(59);
	OUTPUT(92) <= INPUT(60);
	OUTPUT(93) <= INPUT(61);
	OUTPUT(94) <= INPUT(62);
	OUTPUT(95) <= INPUT(63);
	OUTPUT(64) <= INPUT(64);
	OUTPUT(65) <= INPUT(65);
	OUTPUT(66) <= INPUT(66);
	OUTPUT(67) <= INPUT(67);
	OUTPUT(68) <= INPUT(68);
	OUTPUT(69) <= INPUT(69);
	OUTPUT(70) <= INPUT(70);
	OUTPUT(71) <= INPUT(71);
	OUTPUT(40) <= INPUT(72);
	OUTPUT(41) <= INPUT(73);
	OUTPUT(42) <= INPUT(74);
	OUTPUT(43) <= INPUT(75);
	OUTPUT(44) <= INPUT(76);
	OUTPUT(45) <= INPUT(77);
	OUTPUT(46) <= INPUT(78);
	OUTPUT(47) <= INPUT(79);
	OUTPUT(16) <= INPUT(80);
	OUTPUT(17) <= INPUT(81);
	OUTPUT(18) <= INPUT(82);
	OUTPUT(19) <= INPUT(83);
	OUTPUT(20) <= INPUT(84);
	OUTPUT(21) <= INPUT(85);
	OUTPUT(22) <= INPUT(86);
	OUTPUT(23) <= INPUT(87);
	OUTPUT(120) <= INPUT(88);
	OUTPUT(121) <= INPUT(89);
	OUTPUT(122) <= INPUT(90);
	OUTPUT(123) <= INPUT(91);
	OUTPUT(124) <= INPUT(92);
	OUTPUT(125) <= INPUT(93);
	OUTPUT(126) <= INPUT(94);
	OUTPUT(127) <= INPUT(95);
	OUTPUT(96) <= INPUT(96);
	OUTPUT(97) <= INPUT(97);
	OUTPUT(98) <= INPUT(98);
	OUTPUT(99) <= INPUT(99);
	OUTPUT(100) <= INPUT(100);
	OUTPUT(101) <= INPUT(101);
	OUTPUT(102) <= INPUT(102);
	OUTPUT(103) <= INPUT(103);
	OUTPUT(72) <= INPUT(104);
	OUTPUT(73) <= INPUT(105);
	OUTPUT(74) <= INPUT(106);
	OUTPUT(75) <= INPUT(107);
	OUTPUT(76) <= INPUT(108);
	OUTPUT(77) <= INPUT(109);
	OUTPUT(78) <= INPUT(110);
	OUTPUT(79) <= INPUT(111);
	OUTPUT(48) <= INPUT(112);
	OUTPUT(49) <= INPUT(113);
	OUTPUT(50) <= INPUT(114);
	OUTPUT(51) <= INPUT(115);
	OUTPUT(52) <= INPUT(116);
	OUTPUT(53) <= INPUT(117);
	OUTPUT(54) <= INPUT(118);
	OUTPUT(55) <= INPUT(119);
	OUTPUT(24) <= INPUT(120);
	OUTPUT(25) <= INPUT(121);
	OUTPUT(26) <= INPUT(122);
	OUTPUT(27) <= INPUT(123);
	OUTPUT(28) <= INPUT(124);
	OUTPUT(29) <= INPUT(125);
	OUTPUT(30) <= INPUT(126);
	OUTPUT(31) <= INPUT(127);
end ShiftRows_architecture;