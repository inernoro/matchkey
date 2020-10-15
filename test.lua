function exec(num)
    local primevar = 0
    local data = "";
    for number = 0, num do
        isPrime = true
        for i = 2, number - 1 do

            if (number % i == 0) then
                isPrime = false
            else
            end
        end
        if (isPrime) then
            primevar = primevar + 1
            data = data .. "," .. tostring(number);
        end
    end
    return data;
end
