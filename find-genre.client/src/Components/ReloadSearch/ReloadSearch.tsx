import { ReloadIcon } from "@radix-ui/react-icons";
import styles from "./ReloadSearch.module.css";
import { HoverCard, Text } from "@mantine/core";

type Props = {
  handleReload: () => void;
};

const ReloadSearch = (props: Props) => {
  return (
    <HoverCard position="right">
      <HoverCard.Target>
        <ReloadIcon
          onClick={() => props.handleReload()}
          className={styles.icon}
          width={20}
          height={20}
        />
      </HoverCard.Target>
      <HoverCard.Dropdown>
        <Text>Click this button to reset the list</Text>
      </HoverCard.Dropdown>
    </HoverCard>
  );
};

export default ReloadSearch;
