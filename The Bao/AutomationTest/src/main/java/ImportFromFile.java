import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class ImportFromFile {

    public class CSVReader {
        public static final String delimiter = ",";

        public static  List<String> read(String csvFile) {
            List<String> users = new ArrayList<>();
            try {
                File file = new File(csvFile);
                FileReader fr = new FileReader(file);
                BufferedReader br = new BufferedReader(fr);
                String line = " ";
                String[] tempArr;
                br.readLine();
                while ((line = br.readLine()) != null) {
                    tempArr = line.split(delimiter);
                    users.add(tempArr[0]);
//
                }
                br.close();
            } catch (IOException ioe) {
                ioe.printStackTrace();
            }
            return users;
        }
    }


}
