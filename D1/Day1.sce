in = read("input.txt", -1, 1);

// Part 1
for x = 1:length(in)
    for y = 1:length(in)
        if (in(x) + in(y) == 2020)  then
            printf("%d + %d = %d, %d\n", in(x), in(y), in(x)+in(y), in(x)*in(y))
        end
    end
end

// Part 2
for x = 1:length(in)
    for y = 1:length(in)
        for z = 1:length(in)
            if (in(x) + in(y) + in(z) == 2020)  then
                printf("%d + %d + %d = %d, %d\n", in(x), in(y), in(z), in(x)+in(y)+in(z), in(x)*in(y)*in(z))
            end
        end
    end
end
