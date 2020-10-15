local df = require("pp")

env = { input = {},output={}};

env.input.conn = "192.168.0.175@table1";
env.output.conn = "192.168.0.175@table2";
env.other = df();

--通用字段
function Merge( left , right )
	return right;
end