import tkinter as tk
from Question_1 import *


def submit():
    input_lst = input_entry.get().split(',')
    input_n = nth_node_entry.get()

    # input validation
    try:
        input_n = int(input_n)
        if input_n < 1: int('error')
    except ValueError:
        output_label.config(text="Error: Please enter a valid or in range number.")
        return

    try:
        Input_list = [int(x) for x in input_lst]
    except ValueError:
        output_label.config(text="Error: Please enter a valid list of numbers.")
        return

    # calculate the output
    sol = Solution(Input_list, input_n)
    output_linked_list = sol.Lin_lst_remove_n_node()

    if isinstance(output_linked_list, str):
        output_label.config(text=output_linked_list)

    else:
        # display the output
        output_list = []
        while output_linked_list:
            output_list.append(str(output_linked_list.val))
            output_linked_list = output_linked_list.next

        output_label.config(text=' -> '.join(output_list))


root = tk.Tk()
root.title("Linked List Creator")

# input section
input_frame = tk.Frame(root, padx=10, pady=10)
input_frame.pack()

input_label = tk.Label(input_frame, text="Enter a list of comma-separated values:")
input_label.pack()

input_entry = tk.Entry(input_frame, width=40)
input_entry.pack(pady=5)

nth_node_label = tk.Label(input_frame, text="Enter the last index of the node to remove:")
nth_node_label.pack()

nth_node_entry = tk.Entry(input_frame, width=40)
nth_node_entry.pack(pady=5)

# submit button


submit_button = tk.Button(root, text="Submit", command=submit)
submit_button.pack(pady=10)

# output section
output_label = tk.Label(root, text="")
output_label.pack()

root.mainloop()
