task = 2;


if(task ==1)
    % Find and replace all of the "." with ". " and "#" with "# "
    % Import MATLABInput.csv as a String Array
    count = 1;

    for i = 1:length(MATLABInput(:,1))
        if(sum(contains(MATLABInput(count,:),'#')) == 0)
            MATLABInput = [MATLABInput(1:count,:); MATLABInput(count:length(MATLABInput(:,1)),:)];
            count = count+1;
        end
        count = count +1;
    end

    count=1;

    for i = 1:length(MATLABInput(1,:))
        if(sum(contains(MATLABInput(:,count),'#')) == 0)
            MATLABInput = [MATLABInput(:,1:count),  MATLABInput(:,count:length(MATLABInput(1,:)))];
            count = count+1;
        end
        count=count+1;
    end

    writematrix(MATLABInput, 'Advent.csv');
    

elseif(task ==2)
    % Find and replace all of the "." with "1 " and "#" with "0 "
    % Import MATLABInput.csv as a Numeric Matrix 

    for i = 1:length(MATLABInput(1,:))
        if(sum(MATLABInput(:,i) > 0) == length(MATLABInput(:,i)))
            MATLABInput(:,i) = MATLABInput(:,i) + 10
        end
    end

    for i = 1:length(MATLABInput(:,1))
        if(sum(MATLABInput(i,:) > 0) == length(MATLABInput(i,:)))
            MATLABInput(i,:) = MATLABInput(i,:) + 100
        end
    end
    
    writematrix(MATLABInput, 'Advent.csv');
end