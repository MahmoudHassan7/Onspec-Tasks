class Node:
    def __init__(self, val_input_N):
        self.val = val_input_N
        self.next = None


class Linked_list:
    def __init__(self):
        self.head = None

    def add_Node(self, val_input_LL):
        node = Node(val_input_LL)

        if self.head is None: self.head = node
        else:
            tmp_ptr = self.head
            while tmp_ptr.next is not None:
                tmp_ptr = tmp_ptr.next
            tmp_ptr.next = node


class Solution:
    def __init__(self, head_lst, nth_node):
        self.L_list = Linked_list()
        for h_lst in head_lst:
            self.L_list.add_Node(h_lst)

        self.nth_node = nth_node

    def Lin_lst_remove_n_node(self):
        strt_ptr = self.L_list.head
        end_ptr = self.L_list.head

        counter = 0
        while end_ptr.next is not None:
            if counter >= self.nth_node:
                strt_ptr = strt_ptr.next

            end_ptr = end_ptr.next
            counter += 1

        # handle remove start nodes
        # if remove first node or nodes before first one (Error case)
        if self.nth_node - counter > 0:
            # remove first node
            if self.nth_node - counter == 1: self.L_list.head = self.L_list.head.next
            # Error removing node
            else: return "Error: n greater than linked list length"
        # else
        else: strt_ptr.next = strt_ptr.next.next

        return self.L_list.head


def test_run():
    # test run
    head = [1,2,3,4,5]
    n = 1
    sol = Solution(head, n)
    output_linked_list = sol.Lin_lst_remove_n_node()

    if isinstance(output_linked_list, str):
        print("wrong n")
    else:
        # show the output
        while True:
            print(output_linked_list.val)
            output_linked_list = output_linked_list.next
            if output_linked_list is None: break


# # test the code
# test_run()
